import { createSlice, createAsyncThunk, PayloadAction } from '@reduxjs/toolkit';
import {
  fetchProducts,
  createProduct,
  updateProduct,
  GetProductById,
  deleteProduct,
} from '../../API/ProductAPI';
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
export const getProducts = createAsyncThunk(
  'products/getProducts',
  async (query: any) => {
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
  },
);

export const addProduct = createAsyncThunk(
  'products/addProduct',
  async (product: ProductRequest) => {
    const response = await createProduct(product);
    return response;
  },
);

export const editProduct = createAsyncThunk(
  'products/editProduct',
  async ({ id, product }: { id: string; product: ProductRequest }) => {
    const response = await updateProduct(id, product);
    return response;
  },
);

export const removeProduct = createAsyncThunk(
  'products/removeProduct',
  async (id: string) => {
    await deleteProduct(id);
    return id;
  },
);

export const GetbyId = createAsyncThunk(
  'products/getbyid',
  async (id: string) => {
    const response = await GetProductById(id);
    if (response) {
      const product = {
        ...response,
        inventory: response.stock,
        categoryId: response.category.id ?? null, // Sử dụng null nếu category.id không tồn tại
      };

      return product;
    }

    // Nếu response không hợp lệ
    throw new Error('Invalid response format');
  },
);
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
        state.hasNextPage = page * pageSize < totalCount;
        state.hasPreviousPage = page > 1;
      })
      .addCase(getProducts.rejected, (state, action) => {
        state.loading = false;
        state.error = action.error.message || 'Failed to fetch products';
      })
      .addCase(addProduct.pending, (state) => {
        state.loading = true;
        state.error = null;
      })
      .addCase(
        addProduct.fulfilled,
        (state, action: PayloadAction<Product>) => {
          state.loading = false;
          state.items.push(action.payload);
        },
      )
      .addCase(editProduct.pending, (state) => {
        state.loading = true;
        state.error = null;
      })
      .addCase(editProduct.fulfilled, (state, action) => {
        state.loading = false;
        state.items = state.items.filter((item) => item.id !== action.payload);
      })
      .addCase(GetbyId.pending, (state) => {
        state.loading = true;
        state.error = null;
      })
      .addCase(GetbyId.fulfilled, (state, action) => {
        state.loading = false;
        state.items = state.items.filter((item) => item.id !== action.payload);
      })
      .addCase(removeProduct.pending, (state) => {
        state.loading = true;
        state.error = null;
      })
      .addCase(removeProduct.fulfilled, (state, action) => {
        state.loading = false;
        state.items = state.items.filter((item) => item.id !== action.payload);
      })
  },
});

export default productSlice.reducer;
