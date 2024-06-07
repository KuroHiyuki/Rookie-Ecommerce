import React, { useState } from 'react';
import { useDispatch } from 'react-redux';
import { addProduct, getProducts } from '../../Redux/Slice/productSlice';
import { RootState, AppDispatch } from '../../Redux/store';
import { useAppSelector } from '../../Redux/hooks';
import { ProductRequest } from '../../types/product';
import SelectGroupOne from '../Forms/SelectGroup/SelectGroupOne';
import { useNavigate } from 'react-router-dom';

const AddProductForm: React.FC = () => {
  const [name, setName] = useState('');
  const [description, setDescription] = useState('');
  const [price, setPrice] = useState(0);
  const [inventory, setInventory] = useState(0);
  const [categoryId, setCategoryId] = useState('');
  const [imgUrls, setImgUrls] = useState<File[]>([]);
  const dispatch = useDispatch<AppDispatch>();
  const navigate = useNavigate();
  const { loading, error } = useAppSelector(
    (state: RootState) => state.product,
  );
  const handleFileChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    if (e.target.files) {
      setImgUrls(Array.from(e.target.files));
    }
  };
  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault();
    const product = {
      name,
      description,
      price,
      inventory,
      categoryId,
      imgUrls,
    } as ProductRequest;
    dispatch(addProduct(product)).then(() => {
      dispatch(getProducts({ page: 1, pageSize: 10 }));
    });
    setName('');
    setDescription('');
    setPrice(0);
    setInventory(0);
    setCategoryId('');
    setImgUrls([]);
    navigate('/product');
  };
  if (loading) return <p>Loading...</p>;
  if (error) return <p>Error: {error}</p>;
  return (
    <form onSubmit={handleSubmit}>
      <div className="flex flex-col gap-9">
        <div className="rounded-sm border border-stroke bg-white shadow-default dark:border-strokedark dark:bg-boxdark">
          <div className="border-b border-stroke py-4 px-6.5 dark:border-strokedark">
            <h3 className="font-medium text-black dark:text-white">
              Create Product
            </h3>
          </div>
          <div className="p-6.5">
            <div className="mb-4.5 flex flex-col gap-6">
              <div className="w-full">
                <label className="mb-2.5 block text-black dark:text-white">
                  Product Name
                </label>
                <input
                  type="text"
                  className="w-full rounded border-[1.5px] border-stroke bg-transparent py-3 px-5 text-black outline-none transition focus:border-primary active:border-primary disabled:cursor-default disabled:bg-whiter dark:border-form-strokedark dark:bg-form-input dark:text-white dark:focus:border-primary"
                  value={name}
                  onChange={(e) => setName(e.target.value)}
                  required
                />
              </div>

              <div className="w-full">
                <label className="mb-2.5 block text-black dark:text-white">
                  Description
                </label>
                <textarea
                  value={description}
                  onChange={(e) => setDescription(e.target.value)}
                  required
                  className="w-full rounded border-[1.5px] border-stroke bg-transparent py-3 px-5 text-black outline-none transition focus:border-primary active:border-primary disabled:cursor-default disabled:bg-whiter dark:border-form-strokedark dark:bg-form-input dark:text-white dark:focus:border-primary"
                ></textarea>
              </div>
            </div>

            <div className="mb-4.5">
              <label className="mb-2.5 block text-black dark:text-white">
                Unit Price <span className="text-meta-1">*</span>
              </label>
              <input
                type="number"
                value={price}
                onChange={(e) => setPrice(parseFloat(e.target.value))}
                required
                className="w-full rounded border-[1.5px] border-stroke bg-transparent py-3 px-5 text-black outline-none transition focus:border-primary active:border-primary disabled:cursor-default disabled:bg-whiter dark:border-form-strokedark dark:bg-form-input dark:text-white dark:focus:border-primary"
              />
            </div>
            <div className="mb-4.5">
              <label className="mb-2.5 block text-black dark:text-white">
                Inventory <span className="text-meta-1">*</span>
              </label>
              <input
                type="number"
                value={inventory}
                onChange={(e) => setInventory(parseInt(e.target.value, 10))}
                required
                className="w-full rounded border-[1.5px] border-stroke bg-transparent py-3 px-5 text-black outline-none transition focus:border-primary active:border-primary disabled:cursor-default disabled:bg-whiter dark:border-form-strokedark dark:bg-form-input dark:text-white dark:focus:border-primary"
              />
            </div>
            <div className="mb-4.5">
              <label className="mb-2.5 block text-black dark:text-white">
                Category
              </label>
              <input
                type="text"
                value={categoryId}
                className="w-full rounded border-[1.5px] border-stroke bg-transparent py-3 px-5 text-black outline-none transition focus:border-primary active:border-primary disabled:cursor-default disabled:bg-whiter dark:border-form-strokedark dark:bg-form-input dark:text-white dark:focus:border-primary"
                onChange={(e) => setCategoryId(e.target.value)}
                required
              />
            </div>

            <SelectGroupOne />

            <div className="mb-6">
              <div>
                <label className="mb-3 block text-black dark:text-white">
                  Attach file
                </label>
                <input
                  type="file"
                  onChange={handleFileChange}
                  multiple
                  required
                  className="w-full cursor-pointer rounded-lg border-[1.5px] border-stroke bg-transparent outline-none transition file:mr-5 file:border-collapse file:cursor-pointer file:border-0 file:border-r file:border-solid file:border-stroke file:bg-whiter file:py-3 file:px-5 file:hover:bg-primary file:hover:bg-opacity-10 focus:border-primary active:border-primary disabled:cursor-default disabled:bg-whiter dark:border-form-strokedark dark:bg-form-input dark:file:border-form-strokedark dark:file:bg-white/30 dark:file:text-white dark:focus:border-primary"
                />
              </div>
            </div>

            <button
              type="submit"
              disabled={loading}
              className="flex w-full justify-center rounded bg-primary p-3 font-medium text-gray hover:bg-opacity-90"
            >
              Create
            </button>
            {error && <p>Error: {error}</p>}
          </div>
        </div>
      </div>
    </form>
  );
};

export default AddProductForm;
