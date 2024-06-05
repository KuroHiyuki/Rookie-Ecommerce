// src/redux/userSlice.ts
import { createSlice, createAsyncThunk } from '@reduxjs/toolkit';

interface User {
    id: number;
    name: string;
}

interface UserState {
    loading: boolean;
    users: User[];
    error: string | null;
}

const initialState: UserState = {
    loading: false,
    users: [],
    error: null,
};

// Tạo async thunk để fetch users
export const fetchUsers = createAsyncThunk('users/fetchUsers', async () => {
    const response = await fetch('https://jsonplaceholder.typicode.com/users');
    return (await response.json()) as User[];
});

const userSlice = createSlice({
    name: 'users',
    initialState,
    reducers: {},
    extraReducers: (builder) => {
        builder
            .addCase(fetchUsers.pending, (state) => {
                state.loading = true;
                state.error = null;
            })
            .addCase(fetchUsers.fulfilled, (state, action) => {
                state.loading = false;
                state.users = action.payload;
            })
            .addCase(fetchUsers.rejected, (state, action) => {
                state.loading = false;
                state.error = action.error.message || 'Failed to fetch users';
            });
    },
});

export default userSlice.reducer;
