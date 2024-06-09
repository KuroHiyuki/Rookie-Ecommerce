// src/api/categoryApi.ts

import { BASE_URL } from "../config";
import { CategoryRequest } from "../types/category";
import apiFetch from "./APIconfig";


export const fetchCategories = async () => {
    const response = await apiFetch(`${BASE_URL}/category`);
    return response.json();
};

export const createCategory = async (category:CategoryRequest) => {
    const response = await apiFetch(`${BASE_URL}/category`, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(category),
    });
    return response.json();
};

export const updateCategory = async (id:string, category:CategoryRequest) => {
    const response = await apiFetch(`${BASE_URL}/category/${id}`, {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(category),
    });
    return response.json();
};

export const deleteCategory = async (id:string) => {
    const response = await apiFetch(`${BASE_URL}/category/${id}`, {
        method: 'DELETE',
    });
    return response.json();
};
export const fetchCategoryId = async (id:string) => {
    const response = await apiFetch(`${BASE_URL}/category/${id}`,{
        method: 'GET',
    })
    return response.json();
}