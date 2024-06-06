import { createSlice, createAsyncThunk, PayloadAction } from '@reduxjs/toolkit';
import { fetchProducts, createProduct, updateProduct, deleteProduct } from '../../API/ProductAPI';
import { Product, ProductRequest } from '../../types/product';
import { Paginated } from '../../types/Commons/Paginated';

type ProductState = Paginated<Product> & {
	loading: boolean;
    error: string | null;
};

const initialState: ProductState = {
	loading: false,
    error: null,
	hasNextPage: false,
	hasPreviousPage: false,
	items: [],
	page: 1,
	pageSize: 5,
	totalCount: 0,
};


// Async thunks
export const getProducts = createAsyncThunk('products/getProducts', async (query:any ) => {
    const response = await fetchProducts(query);
    const products = response.items.map((product: any) => ({
        ...product,
        Inventory: product.stock,
        CreatedDate: new Date(product.createdAt).toLocaleDateString('en-GB'),
        category: product.category.name,
        image: product.images.length > 0 ? product.images[0] : 'N/A',
    }));

    return {
        ...response,
        items: products,
    };
});

export const addProduct = createAsyncThunk('products/addProduct', async (product: ProductRequest) => {
    const response = await createProduct(product);
    return response;
});

export const editProduct = createAsyncThunk('products/editProduct', async ({ id, product }: { id: string; product: any }) => {
    const response = await updateProduct(id, product);
    return response;
});

export const removeProduct = createAsyncThunk('products/removeProduct', async (id: string) => {
    await deleteProduct(id);
    return id;
});

const productSlice = createSlice({
    name: 'products',
    initialState,
    reducers: {},
    extraReducers: (builder) => {
        builder
            .addCase(getProducts.pending, (state) => {
                state.loading = true;
            })
            .addCase(getProducts.fulfilled, (state, action) => {
                const { items, totalCount, page, pageSize } = action.payload;
                state.loading = false;
                state.items = items;
                state.totalCount = totalCount;
                state.page = page;
                state.pageSize = pageSize;
                state.hasNextPage = (page * pageSize) < totalCount;
                state.hasPreviousPage = page > 1;
            })
            .addCase(getProducts.rejected, (state, action) => {
                state.loading = false;
                state.error = action.error.message || 'Failed to fetch products';
            });
        builder
            .addCase(addProduct.pending, (state) => {
                state.loading = true;
                state.error = null;
            })
            .addCase(addProduct.fulfilled, (state, action: PayloadAction<Product>) => {
                state.loading = false;
                state.items.push(action.payload);
            })
            // .addCase(addProduct.rejected, (state, action) => {
            //     state.loading = false;
            //     state.error = action.error.message || 'Failed to create product';
            // });
    },
});

export default productSlice.reducer;