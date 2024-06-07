import React, { useState } from 'react';
import { useAppDispatch, useAppSelector } from '../../Redux/hooks';
import { useNavigate } from 'react-router-dom';
import { CategoryRequest } from '../../types/category';
import { addCategory, getCategories } from '../../Redux/Slice/categorySlice';

const AddCategory: React.FC = () => {
  const [name, setName] = useState('');
  const [Description, setDescription] = useState('');
  const dispatch = useAppDispatch();

  const { loading, error } = useAppSelector((state) => state.category);
  const navigate = useNavigate();

  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault();
    const category = {
        name,
        Description
    } as CategoryRequest;
    dispatch(addCategory(category)).then(() => {
        dispatch(getCategories())});;
    setName('');
    setDescription('');
    navigate('/category');
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
                  value={Description}
                  onChange={(e) => setDescription(e.target.value)}
                  required
                  className="w-full rounded border-[1.5px] border-stroke bg-transparent py-3 px-5 text-black outline-none transition focus:border-primary active:border-primary disabled:cursor-default disabled:bg-whiter dark:border-form-strokedark dark:bg-form-input dark:text-white dark:focus:border-primary"
                ></textarea>
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
      </div>
    </form>
  );
};

export default AddCategory;
