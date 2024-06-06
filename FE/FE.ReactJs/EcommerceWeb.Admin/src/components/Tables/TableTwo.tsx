import { Product } from '../../types/product';
import ProductOne from '../../images/product/product-01.png';
import ProductTwo from '../../images/product/product-02.png';
import { useAppDispatch, useAppSelector } from '../../Redux/hooks';
import { useEffect } from 'react';
import { getProducts } from '../../Redux/Slice/productSlice';

const TableTwo: React.FC = () => {
  const dispatch = useAppDispatch();
  const {
    loading,
    items,
    error,
    page,
    pageSize,
    totalCount,
    hasNextPage,
    hasPreviousPage,
  } = useAppSelector((state) => state.product);

  useEffect(() => {
    dispatch(getProducts({ page: 1, pageSize: 2 }));
  }, [dispatch]);
  const handleNextPage = () => {
    if (hasNextPage) {
      dispatch(getProducts({ page: page + 1, pageSize }));
    }
  };

  const handlePreviousPage = () => {
    if (hasPreviousPage) {
      dispatch(getProducts({ page: page - 1, pageSize }));
    }
  };
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
        <div className="col-span-3 flex items-center">
          <p className="font-medium">Product Name</p>
        </div>
        <div className="col-span-1 hidden items-center sm:flex">
          <p className="font-medium">Category</p>
        </div>
        <div className="col-span-1 flex items-center">
          <p className="font-medium">Price</p>
        </div>
        <div className="col-span-2 flex items-center">
          <p className="font-medium">Description</p>
        </div>
        <div className="col-span-1 flex items-center">
          <p className="font-medium">Created Date</p>
        </div>
      </div>

      {items.map((product) => (
        <div
          className="grid grid-cols-6 border-t border-stroke py-4.5 px-4 dark:border-strokedark sm:grid-cols-8 md:px-6 2xl:px-7.5"
          key={product.id}
        >
          <div className="col-span-3 flex items-center">
            <div className="flex flex-col gap-4 sm:flex-row sm:items-center">
              <div className="h-12.5 w-15 rounded-md">
                <img src={product.image} alt="Product" />
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
          <div className="col-span-2 flex items-center">
            <p className="text-sm text-black dark:text-white">
              {product.description}
            </p>
          </div>
          <div className="col-span-1 flex items-center">
            <p className="text-sm text-meta-3">{product.CreatedDate}</p>
          </div>
        </div>
      ))}
      <div>
        <button onClick={handlePreviousPage} disabled={!hasPreviousPage}>
          Previous
        </button>
        <span>Page {page}</span>
        <button onClick={handleNextPage} disabled={!hasNextPage}>
          Next
        </button>
      </div>
    </div>
  );
};

export default TableTwo;
