// src/redux/slices/categorySlice.ts
import { createSlice, createAsyncThunk } from '@reduxjs/toolkit';
import { fetchCategories, createCategory, updateCategory, deleteCategory } from '../../API/CategoryAPI';
import { Category, CategoryRequest } from '../../types/category';

interface CategoryState {
    loading: boolean;
    categories: Category[];
    error: string | null;
}

const initialState: CategoryState = {
    loading: false,
    categories: [],
    error: null,
};

// Async thunks
export const getCategories = createAsyncThunk('categories/getCategories', async () => {
    const response = await fetchCategories();
    return response;
});

export const addCategory = createAsyncThunk('categories/addCategory', async (category: CategoryRequest) => {
    const response = await createCategory(category);
    return response;
});

export const editCategory = createAsyncThunk('categories/editCategory', async ({ id, category }: { id: string; category: CategoryRequest }) => {
    const response = await updateCategory(id, category);
    return response;
});

export const removeCategory = createAsyncThunk('categories/removeCategory', async (id: string) => {
    await deleteCategory(id);
    return id;
});

const categorySlice = createSlice({
    name: 'categories',
    initialState,
    reducers: {},
    extraReducers: (builder) => {
        builder
            .addCase(getCategories.pending, (state) => {
                state.loading = true;
            })
            .addCase(getCategories.fulfilled, (state, action) => {
                state.loading = false;
                state.categories = action.payload;
            })
            .addCase(getCategories.rejected, (state, action) => {
                state.loading = false;
                state.error = action.error.message || 'Failed to fetch categories';
            })
            .addCase(addCategory.fulfilled, (state, action) => {
                state.categories.push(action.payload);
            })
            .addCase(editCategory.fulfilled, (state, action) => {
                const index = state.categories.findIndex(category => category.id === action.payload.id);
                if (index !== -1) {
                    state.categories[index] = action.payload;
                }
            })
            .addCase(removeCategory.fulfilled, (state, action) => {
                state.categories = state.categories.filter(category => category.id !== action.payload);
            });
    },
});

export default categorySlice.reducer;
