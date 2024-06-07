// src/components/UserList.tsx
import React, { useEffect } from 'react';
import { useAppDispatch, useAppSelector } from '../../Redux/hooks';
import { getUsers, removeUser } from '../../Redux/Slice/userSlice';
import { BASE_URL } from '../../config';
import { Link } from 'react-router-dom';

const UserList: React.FC = () => {
    const dispatch = useAppDispatch();
    const { loading, users, error } = useAppSelector((state) => state.user);
    const handleDelete = (id: string) => {
        dispatch(removeUser(id)).then(() => {
            dispatch(getUsers());
          });;
      };
    useEffect(() => {
        dispatch(getUsers());
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
        <div className="col-span-3 flex items-center">
          <p className="font-medium">Name</p>
        </div>
        <div className="col-span-1 hidden items-center sm:flex">
          <p className="font-medium">Email</p>
        </div>
        <div className="col-span-1 flex items-center">
          <p className="font-medium">Telephone</p>
        </div>
        <div className="col-span-1 flex items-center">
          <p className="font-medium">Address</p>
        </div>
        <div className="col-span-2 flex items-center">
          <p className="font-medium">Action</p>
        </div>
      </div>
      <div>
            <h1>User List</h1>
            <ul>
                {users.map(user => (
                    <li key={user.Id}>
                        {user.FirstName}
                        <button onClick={() => dispatch(removeUser(user.Id))}>Delete</button>
                    </li>
                ))}
            </ul>
        </div>
      {users.map((user) => (
        <div
          className="grid grid-cols-6 border-t border-stroke py-4.5 px-4 dark:border-strokedark sm:grid-cols-8 md:px-6 2xl:px-7.5"
          key={user.Id}
        >
          <div className="col-span-2 flex items-center m-r-2">
            <div className="flex flex-col gap-4 sm:flex-row sm:items-center">
              <div className="h-12.5 w-15 rounded-md">
                <img
                  className="h-12.5 w-15 rounded-md"
                  src={`${BASE_URL}/uploads/${user.AvatarURL}`}
                  alt="Product"
                />
              </div>
              <p className="text-sm text-black dark:text-white">
                {`${user.FirstName} +${user.LastName}`}
              </p>
            </div>
          </div>
          <div className="col-span-1 hidden items-center sm:flex">
            <p className="text-sm text-black dark:text-white">
              {user.Email}
            </p>
          </div>
          <div className="col-span-1 flex items-center">
            <p className="text-sm text-black dark:text-white">
              ${user.NumberPhone}
            </p>
          </div>
          <div className="col-span-1 flex items-center">
            <p className="text-sm text-black dark:text-white">
              {user.Address}
            </p>
          </div>
          <div className="col-span-2 flex items-center">
            <Link
              to={`/product/edit/${user.Id}`}
              className="inline-flex items-center justify-center rounded-md border border-warning py-4 px-10 text-center font-medium text-warning hover:bg-opacity-90 lg:px-8 xl:px-10 gap-10 m-b-sm"
            >
              Edit
            </Link>
            <button
              onClick={() => handleDelete(user.Id)}
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

export default UserList;
