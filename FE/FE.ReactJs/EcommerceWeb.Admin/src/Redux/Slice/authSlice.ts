
import { createSlice, createAsyncThunk } from '@reduxjs/toolkit';
import { fetchAuth } from '../../API/AuthAPI';

interface AuthState {
    token: string | null;
    id: string | null;
    FirstName: string |null,
    Email: string |'',
    LastName: string|null,
    loading: boolean;
    numberPhone: string|'',
    error: string | null;
  }
  
  const initialState: AuthState = {
    token: null,
    id: null,
    FirstName: null,
    LastName:null,
    Email: '',
    numberPhone: '',
    loading: false,
    error: null,
  };


  export const SignInAdmin = createAsyncThunk(
    'auth/signin',
    async (credentials: { email: string; password: string }) => {
        const response = await fetchAuth(credentials);
        const { token } = response;
        sessionStorage.setItem('authToken', token);
        return response
    },
);

const authSlice = createSlice({
  name: 'auth',
  initialState,
  reducers: {},
  extraReducers: (builder) => {
    builder
    .addCase(SignInAdmin.pending, (state) => {
        state.loading = true;
        state.error = null;
      })
      .addCase(SignInAdmin.fulfilled, (state, action) => {
        state.loading = false;
        state.token = action.payload.token;
        state.id = action.payload.id;
        state.FirstName = action.payload.firstName,
        state.LastName = action.payload.lastName,
        state.Email = action.payload.email,
        state.numberPhone = action.payload.numberPhone
      })
      .addCase(SignInAdmin.rejected, (state, action) => {
        state.loading = false;
        state.error = action.error.message || 'Something went wrong';
      });
  },
});

export default authSlice.reducer;
