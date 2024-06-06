// src/components/ProductList.tsx
import React, { useEffect } from 'react';
import { useAppDispatch, useAppSelector } from '../../Redux/hooks';
import { getProducts, addProduct, editProduct, removeProduct } from '../../Redux/Slice/productSlice';

const ProductList: React.FC = () => {
    const dispatch = useAppDispatch();
    const { loading, items, error, page, pageSize, totalCount, hasNextPage, hasPreviousPage } = useAppSelector((state) => state.product);

    useEffect(() => {
        dispatch(getProducts({ page: 1, pageSize: 10 }));
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
        <div>
            <h1>Product List</h1>
            <ul>
                {items.map(product => (
                    <li key={product.id}>
                        {product.name} - {product.description} - ${product.price}
                    </li>
                ))}
            </ul>
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

export default ProductList;
