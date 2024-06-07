// src/api/categoryApi.ts

import { BASE_URL } from "../config";
import { CategoryRequest } from "../types/category";


export const fetchCategories = async () => {
    const response = await fetch(`${BASE_URL}/category`);
    return response.json();
};

export const createCategory = async (category:CategoryRequest) => {
    const response = await fetch(`${BASE_URL}/category`, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(category),
    });
    return response.json();
};

export const updateCategory = async (id:string, category:CategoryRequest) => {
    const response = await fetch(`${BASE_URL}/category/${id}`, {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(category),
    });
    return response.json();
};

export const deleteCategory = async (id:string) => {
    const response = await fetch(`${BASE_URL}/category/${id}`, {
        method: 'DELETE',
    });
    return response.json();
};
