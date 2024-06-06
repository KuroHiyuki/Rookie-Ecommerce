// src/components/AddProductForm.tsx
import React, { useState } from 'react';
import { useDispatch } from 'react-redux';
import { addProduct } from '../../Redux/Slice/productSlice';
import { RootState, AppDispatch } from '../../Redux/store';
import { useAppSelector } from '../../Redux/hooks';
import { ProductRequest } from '../../types/product';

const AddProductForm: React.FC = () => {
    const [name, setName] = useState('');
    const [description, setDescription] = useState('');
    const [price, setPrice] = useState(0);
    const [CreatedDate,setCreatedDate ] = useState('');
    const [inventory, setInventory] = useState(0);
    const [categoryId, setCategoryId] = useState('');
    const [imgUrls, setImgUrls] = useState<string[]>([]);
    const dispatch = useDispatch<AppDispatch>();
    const { loading, error } = useAppSelector((state: RootState) => state.product);

    const handleSubmit = (e: React.FormEvent) => {
        e.preventDefault();
        const product = {
            name, description, price, CreatedDate, inventory, categoryId, imgUrls
        } as ProductRequest
        dispatch(addProduct(product));
        setName('');
        setDescription('');
        setPrice(0);
        setCreatedDate('');
        setInventory(0);
        setCategoryId('');
        setImgUrls([]);
    };
    if (loading) return <p>Loading...</p>;
    if (error) return <p>Error: {error}</p>;
    return (
        <form onSubmit={handleSubmit}>
            <div>
                <label>Name</label>
                <input
                    type="text"
                    value={name}
                    onChange={(e) => setName(e.target.value)}
                    required
                />
            </div>
            <div>
                <label>Description</label>
                <input
                    type="text"
                    value={description}
                    onChange={(e) => setDescription(e.target.value)}
                    required
                />
            </div>
            <div>
                <label>Price</label>
                <input
                    type="number"
                    value={price}
                    onChange={(e) => setPrice(parseFloat(e.target.value))}
                    required
                />
            </div>
            <div>
                <label>Created At</label>
                <input
                    type="date"
                    value={CreatedDate}
                    onChange={(e) => setCreatedDate(e.target.value)}
                    required
                />
            </div>
            <div>
                <label>Stock</label>
                <input
                    type="number"
                    value={inventory}
                    onChange={(e) => setInventory(parseInt(e.target.value, 10))}
                    required
                />
            </div>
            <div>
                <label>Category</label>
                <input
                    type="text"
                    value={categoryId}
                    onChange={(e) => setCategoryId(e.target.value)}
                    required
                />
            </div>
            <div>
                <label>Images</label>
                <input
                    type="text"
                    value={imgUrls.join(',')}
                    onChange={(e) => setImgUrls(e.target.value.split(','))}
                    required
                />
            </div>
            <button type="submit" disabled={loading}>Add Product</button>
            {error && <p>Error: {error}</p>}
        </form>
    );
};

export default AddProductForm;