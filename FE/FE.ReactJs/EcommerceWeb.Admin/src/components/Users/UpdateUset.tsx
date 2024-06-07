import React, { useEffect, useState } from 'react';
import { useAppDispatch, useAppSelector } from '../../Redux/hooks';
import { useNavigate, useParams } from 'react-router-dom';
import { editUser, getUserId, getUsers } from '../../Redux/Slice/userSlice';
import { UserRequest } from '../../types/User';

const UpdatUser: React.FC = () => {
  const { id } = useParams<{ id: string }>();
  const [firstName, setfirstName] = useState('');
  const [lastName, setlastName] = useState('');
  const [email, setemail] = useState('');
  const [numberPhone, setnumberPhone] = useState('');
  const [address, setaddress] = useState('');

  const dispatch = useAppDispatch();
    const { loading, users, error } = useAppSelector((state) => state.user);
  
  const navigate = useNavigate();
  

  useEffect(() => {
    if (id) {
      dispatch(getUserId(id));
    }
  }, [dispatch, id]);

  useEffect(() => {
    if (users && id) {
      const user = users.find((item) => item.id === id);
      if (user) {
        setfirstName(user.firstName);
        setlastName(user.lastName);
        setemail(user.email);
        setnumberPhone(user.numberPhone);
        setaddress(user.address);
      }
    }
  }, [users, id]);
  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault();
    const user = {
        firstName,
        lastName,
        email,
        numberPhone,
        address,
    } as UserRequest;
    dispatch(editUser({ id: id!, user: user })).then(() => {
        dispatch(getUsers());
      });
      setfirstName('');
      setlastName('');
      setemail('');
      setnumberPhone('');
      setaddress('');
    navigate('/user');
  };
  if (loading) return <p>Loading...</p>;
  if (error) return <p>Error: {error}</p>;
  return (
    <form onSubmit={handleSubmit}>
      <div className="flex flex-col gap-9">
        {/* <!-- Contact Form --> */}
        <div className="rounded-sm border border-stroke bg-white shadow-default dark:border-strokedark dark:bg-boxdark">
          <div className="border-b border-stroke py-4 px-6.5 dark:border-strokedark">
            <h3 className="font-medium text-black dark:text-white">
              Edit User Information
            </h3>
          </div>
          <div className="p-6.5">
            <div className="mb-4.5 flex flex-col gap-6">
              <div className="w-full">
                <label className="mb-2.5 block text-black dark:text-white">
                  First Name
                </label>
                <input
                  type="text"
                  className="w-full rounded border-[1.5px] border-stroke bg-transparent py-3 px-5 text-black outline-none transition focus:border-primary active:border-primary disabled:cursor-default disabled:bg-whiter dark:border-form-strokedark dark:bg-form-input dark:text-white dark:focus:border-primary"
                  value={firstName}
                  onChange={(e) => setfirstName(e.target.value)}
                  required
                />
              </div>

              <div className="w-full">
                <label className="mb-2.5 block text-black dark:text-white">
                  Last Name
                </label>
                <input
                  value={lastName}
                  onChange={(e) => setlastName(e.target.value)}
                  required
                  className="w-full rounded border-[1.5px] border-stroke bg-transparent py-3 px-5 text-black outline-none transition focus:border-primary active:border-primary disabled:cursor-default disabled:bg-whiter dark:border-form-strokedark dark:bg-form-input dark:text-white dark:focus:border-primary"
                />
              </div>
            </div>

            <div className="w-full">
                <label className="mb-2.5 block text-black dark:text-white">
                  Email
                </label>
                <input
                  value={email}
                  onChange={(e) => setemail(e.target.value)}
                  required
                  className="w-full rounded border-[1.5px] border-stroke bg-transparent py-3 px-5 text-black outline-none transition focus:border-primary active:border-primary disabled:cursor-default disabled:bg-whiter dark:border-form-strokedark dark:bg-form-input dark:text-white dark:focus:border-primary"
                />
              </div>
            <div className="w-full">
                <label className="mb-2.5 block text-black dark:text-white">
                  numberPhone
                </label>
                <input
                  value={lastName}
                  onChange={(e) => setnumberPhone(e.target.value)}
                  required
                  className="w-full rounded border-[1.5px] border-stroke bg-transparent py-3 px-5 text-black outline-none transition focus:border-primary active:border-primary disabled:cursor-default disabled:bg-whiter dark:border-form-strokedark dark:bg-form-input dark:text-white dark:focus:border-primary"
                />
              </div>
              <div className="w-full">
                <label className="mb-2.5 block text-black dark:text-white">
                  Address
                </label>
                <input
                  value={address}
                  onChange={(e) => setaddress(e.target.value)}
                  required
                  className="w-full rounded border-[1.5px] border-stroke bg-transparent py-3 px-5 text-black outline-none transition focus:border-primary active:border-primary disabled:cursor-default disabled:bg-whiter dark:border-form-strokedark dark:bg-form-input dark:text-white dark:focus:border-primary"
                />
              </div>
            </div>
            <button
              type="submit"
              disabled={loading}
              className="flex w-full justify-center rounded bg-primary p-3 font-medium text-gray hover:bg-opacity-90"
            >
              Save
            </button>
            {error && <p>Error: {error}</p>}
          </div>
        </div>
    </form>
  );
};

export default UpdatUser;
