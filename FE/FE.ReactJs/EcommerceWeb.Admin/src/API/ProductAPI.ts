                                                                                                              import { BASE_URL } from '../config';
import { Query } from '../types/Commons/Query';
import { ProductRequest } from '../types/product';


export const fetchProducts = async (query: Query) => {
    const url = new URL(`${BASE_URL}/product`);
    const params = new URLSearchParams(query as any);

    url.search = params.toString();

    const response = await fetch(url.toString());
    return response.json();
};

export const createProduct = async (product:ProductRequest) => {
    const response = await fetch(`${BASE_URL}/product`, {
        method: 'POST',                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(product),
    });
    return response.json();
};

export const updateProduct = async (id:string, product:ProductRequest) => {
    const response = await fetch(`${BASE_URL}/product/${id}`, {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(product),
    });
    return response.json();
};

export const deleteProduct = async (id:string) => {
    const response = await fetch(`${BASE_URL}/products/${id}`, {
        method: 'DELETE',
    });
    return response.json();
};