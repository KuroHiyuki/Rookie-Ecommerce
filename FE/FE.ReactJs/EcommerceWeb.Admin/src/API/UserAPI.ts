import { BASE_URL } from "../config";
import { UserRequest } from "../types/User";

export const fetchUsers = async () => {
    const response = await fetch(`${BASE_URL}/user`);
    return response.json();
};

export const updateUser = async (id:string, user:UserRequest) => {
    const response = await fetch(`${BASE_URL}/user/${id}`, {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(user),
    });
    return response.json();
};

export const deleteUser = async (id:string) => {
    const response = await fetch(`${BASE_URL}/user/${id}`, {
        method: 'DELETE',
    });
    return response.json();
};

export const fetchUserID = async (id:string) => {
    const response = await fetch(`${BASE_URL}/user/${id}`, {
        method: 'GET',
    });
    return response.json();
};
