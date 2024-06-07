import { useAppDispatch, useAppSelector } from '../../Redux/hooks';
import { useEffect } from 'react';
import { getProducts, removeProduct } from '../../Redux/Slice/productSlice';
import CircularPagination from '../Pagination/CircularPagination';
import { BASE_URL } from '../../config';
import { Link } from 'react-router-dom';

const ProductList: React.FC = () => {
  const dispatch = useAppDispatch();
  const { loading, items, error } = useAppSelector((state) => state.product);
  const handleDelete = (id: string) => {
    dispatch(removeProduct(id)).then(() => {
        dispatch(getProducts({ page: 1, pageSize: 10 }));
      });;
  };
  useEffect(() => {
    dispatch(getProducts({ page: 1, pageSize: 10 }));
  }, [dispatch]);
  if (loading) return <p>Loading...</p>;
  if (error) return <p>Error: {error}</p>;
  return (
    <div className="rounded-sm border border-stroke bg-white shadow-default dark:border-strokedark dark:bg-boxdark">
      <div className="py-6 px-4 md:px-6 xl:px-7.5">
        <h4 className="text-xl font-semibold text-black dark:text-white">
          Top Products
        </h4>
      </div>

      <div className="grid grid-cols-8 border-t border-stroke py-4.5 px-4 dark:border-strokedark sm:grid-cols-8 md:px-6 2xl:px-7.5">
        <div className="col-span-2 flex items-center">
          <p className="font-medium">Product Name</p>
        </div>
        <div className="col-span-1 hidden items-center sm:flex">
          <p className="font-medium">Category</p>
        </div>
        <div className="col-span-1 flex items-center">
          <p className="font-medium">Price</p>
        </div>
        <div className="col-span-1 flex items-center">
          <p className="font-medium">Inventory</p>
        </div>
        <div className="col-span-1 flex items-center">
          <p className="font-medium">Created Date</p>
        </div>
        <div className="col-span-2 flex items-center">
          <p className="font-medium">Action</p>
        </div>
      </div>

      {items.map((product) => (
        <div
          className="grid grid-cols-6 border-t border-stroke py-4.5 px-4 dark:border-strokedark sm:grid-cols-8 md:px-6 2xl:px-7.5"
          key={product.id}
        >
          <div className="col-span-2 flex items-center m-r-2">
            <div className="flex flex-col gap-4 sm:flex-row sm:items-center">
              <div className="h-12.5 w-15 rounded-md">
                <img
                  className="h-12.5 w-15 rounded-md"
                  src={`${BASE_URL}/uploads/${product.image}`}
                  alt="Product"
                />
              </div>
              <p className="text-sm text-black dark:text-white">
                {product.name}
              </p>
            </div>
          </div>
          <div className="col-span-1 hidden items-center sm:flex">
            <p className="text-sm text-black dark:text-white">
              {product.category}
            </p>
          </div>
          <div className="col-span-1 flex items-center">
            <p className="text-sm text-black dark:text-white">
              ${product.price}
            </p>
          </div>
          <div className="col-span-1 flex items-center">
            <p className="text-sm text-black dark:text-white">
              {product.Inventory}
            </p>
          </div>
          <div className="col-span-1 flex items-center">
            <p className="text-sm text-meta-3">{product.CreatedDate}</p>
          </div>
          <div className="col-span-2 flex items-center">
            <Link
              to={`/product/edit/${product.id}`}
              className="inline-flex items-center justify-center rounded-md border border-warning py-4 px-10 text-center font-medium text-warning hover:bg-opacity-90 lg:px-8 xl:px-10 gap-10 m-b-sm"
            >
              Edit
            </Link>
            <button
              onClick={() => handleDelete(product.id)}
              className="inline-flex items-center justify-center rounded-md border border-danger py-4 px-10 text-center font-medium text-danger hover:bg-opacity-90 lg:px-8 xl:px-10 gap-10 m-b-sm"
            >
              Delete
            </button>
          </div>
        </div>
      ))}
      <div className="col-span-6 flex items-center">
        <CircularPagination />
      </div>
    </div>
  );
};

export default ProductList;
