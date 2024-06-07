// src/components/CategoryList.tsx
import React, { useEffect } from 'react';
import { useAppDispatch, useAppSelector } from '../../Redux/hooks';
import { getCategories, removeCategory } from '../../Redux/Slice/categorySlice';
import { Link } from 'react-router-dom';

const CategoryList: React.FC = () => {
    const dispatch = useAppDispatch();
    const { loading, categories, error } = useAppSelector((state) => state.category);

    useEffect(() => {
        dispatch(getCategories());
    }, [dispatch]);

    if (loading) return <p>Loading...</p>;
    if (error) return <p>Error: {error}</p>;

    return (
        <div className="rounded-sm border border-stroke bg-white shadow-default dark:border-strokedark dark:bg-boxdark">
      <div className="py-6 px-4 md:px-6 xl:px-7.5">
        <h4 className="text-xl font-semibold text-black dark:text-white">
          Category List
        </h4>
      </div>

      <div className="grid grid-cols-8 border-t border-stroke py-4.5 px-4 dark:border-strokedark sm:grid-cols-8 md:px-6 2xl:px-7.5">
        <div className="col-span-2 flex items-center">
          <p className="font-medium">Category Name</p>
        </div>
        <div className="col-span-4 hidden items-center sm:flex">
          <p className="font-medium">Description</p>
        </div>
        <div className="col-span-2 flex items-center text-center">
          <p className="font-medium">Action</p>
        </div>
      </div>
      {categories.map(category => (
        <div
          className="grid grid-cols-6 border-t border-stroke py-4.5 px-4 dark:border-strokedark sm:grid-cols-8 md:px-6 2xl:px-7.5"
          key={category.id}
        >
          <div className="col-span-2 flex items-center m-r-2">
            <div className="flex flex-col gap-4 sm:flex-row sm:items-center">
              <p className="text-sm text-black dark:text-white">
                {category.name}
              </p>
            </div>
          </div>
          <div className="col-span-4 hidden items-center sm:flex ">
            <p className="text-sm text-black dark:text-white mr-10">
              {category.description}
            </p>
          </div>
          <div className="col-span-2 flex items-center">
            <Link
              to={`/category/edit/${category.id}`}
              className="inline-flex items-center justify-center rounded-md border border-warning py-4 px-10 text-center font-medium text-warning hover:bg-opacity-90 lg:px-8 xl:px-10 gap-10 m-b-sm"
            >
              Edit
            </Link>
            <button
              onClick={() => dispatch(removeCategory(category.id)).then(() => {
                dispatch(getCategories())})}
              className="ml-1 inline-flex items-center justify-center rounded-md border border-danger py-4 px-10 text-center font-medium text-danger hover:bg-opacity-90 lg:px-8 xl:px-10 gap-10 m-b-sm"
            >
              Delete
            </button>
          </div>
        </div>
      ))}
      <div className="col-span-6 flex items-center">
      </div>
    </div>
    );
};

export default CategoryList;
