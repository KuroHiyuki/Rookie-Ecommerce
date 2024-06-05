// src/UserList.tsx
import React, { useEffect } from 'react';
import { useSelector, useDispatch } from 'react-redux';
import { RootState, AppDispatch } from './Redux/store';
import { fetchUsers } from './Redux/userSlice';

const UserList: React.FC = () => {
    const dispatch = useDispatch<AppDispatch>();
    const { loading, users, error } = useSelector((state: RootState) => state.user);

    useEffect(() => {
        dispatch(fetchUsers());
    }, [dispatch]);

    if (loading) return <p>Loading...</p>;
    if (error) return <p>Error: {error}</p>;

    return (
        <div>
            <h1>User List</h1>
            <ul>
                {users.map(user => (
                    <li key={user.id}>{user.name}</li>
                ))}
            </ul>
        </div>
    );
};

export default UserList;
