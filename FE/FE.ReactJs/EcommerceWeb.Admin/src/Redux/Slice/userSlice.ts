// src/redux/slices/userSlice.ts
import { createSlice, createAsyncThunk } from '@reduxjs/toolkit';
import { fetchUsers, updateUser, deleteUser, fetchUserID } from '../../API/UserAPI';
import { User, UserRequest } from '../../types/User';

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

// Async thunks
export const getUsers = createAsyncThunk('users/getUsers', async () => {
    const response = await fetchUsers();
    return response;
});

export const editUser = createAsyncThunk('users/editUser', async ({ id, user }: { id: string; user: UserRequest }) => {
    const response = await updateUser(id, user);
    return response;
});

export const removeUser = createAsyncThunk('users/removeUser', async (id: string) => {
    await deleteUser(id);
    return id;
});

export const getUserId = createAsyncThunk('users/getUserId', async (id: string) => {
    var response = await fetchUserID(id);
    return response;
});
const userSlice = createSlice({
    name: 'users',
    initialState,
    reducers: {},
    extraReducers: (builder) => {
        builder
            .addCase(getUsers.pending, (state) => {
                state.loading = true;
            })
            .addCase(getUsers.fulfilled, (state, action) => {
                state.loading = false;
                state.users = action.payload;
            })
            .addCase(getUsers.rejected, (state, action) => {
                state.loading = false;
                state.error = action.error.message || 'Failed to fetch users';
            })
            .addCase(editUser.fulfilled, (state, action) => {
                const index = state.users.findIndex(user => user.id === action.payload.id);
                if (index !== -1) {
                    state.users[index] = action.payload;
                }
            })
            .addCase(removeUser.fulfilled, (state, action) => {
                state.users = state.users.filter(user => user.id !== action.payload);
            })
            .addCase(getUserId.pending, (state) => {
                state.loading = true;
              })
              .addCase(getUserId.fulfilled, (state, action) => {
                state.loading = false;
                state.users = state.users.filter((item) => item.id !== action.payload);
              })
    },
});

export default userSlice.reducer;
