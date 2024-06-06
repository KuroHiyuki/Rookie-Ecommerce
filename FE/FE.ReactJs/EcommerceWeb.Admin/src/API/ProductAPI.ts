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

export const createProduct = async (product: ProductRequest) => {
  const formData = new FormData();
  formData.append('Name', product.name);
  formData.append('Description', product.description);
  formData.append('Price', product.price.toString());
  formData.append('Stock', product.inventory.toString());
  formData.append('CategoryId', product.categoryId);

  product.imgUrls.forEach((image) => {
    formData.append('images', image);
  });

  const response = await fetch(`${BASE_URL}/product`, {
    method: 'POST',
    body: formData,
  });
  if (!response.ok) {
    throw new Error('Failed to create product');
  }
  console.log(response);
  return response.json();
};

export const updateProduct = async (id: string, product: ProductRequest) => {
  // const formData = new FormData();
  // formData.append('Name', product.name);
  // formData.append('Description', product.description);
  // formData.append('Price', product.price.toString());
  // formData.append('CreatedAt', product.CreatedDate);
  // formData.append('Stock', product.inventory.toString());
  // formData.append('CategoryId', product.categoryId);

  // product.imgUrls.forEach((image, index) => {
  //     formData.append(`Images[${index}]`, image);
  // });

  const response = await fetch(`${BASE_URL}/product/${id}`, {
    method: 'PUT',
    headers: {
      'Content-Type': 'jsonbody',
    },
    body: JSON.stringify(product),
  });
  return response.json();
};

export const deleteProduct = async (id: string) => {
  const response = await fetch(`${BASE_URL}/products/${id}`, {
    method: 'DELETE',
  });
  return response.json();
};
