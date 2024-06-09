
import { createSlice, createAsyncThunk } from '@reduxjs/toolkit';
import { fetchAuth } from '../../API/AuthAPI';
import { SignIn } from '../../types/Auth';
import Cookies from 'js-cookie';
interface AuthState {
    token: string | null;
    user: SignIn|null;
    loading: boolean;
    error: string | null;
  }
  
  const initialState: AuthState = {
    token: null,
    user: null,
    loading: false,
    error: null,
  };


  export const SignInAdmin = createAsyncThunk(
    'auth/signin',
    async (credentials: { email: string; password: string }) => {
        const response = await fetchAuth(credentials);
        const { token } = response;
        Cookies.set('authToken', token, { expires: 1 });
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
        state.user = action.payload
      })
      .addCase(SignInAdmin.rejected, (state, action) => {
        state.loading = false;
        state.error = action.error.message || 'Something went wrong';
      });
  },
});

export default authSlice.reducer;
