import { configureStore } from '@reduxjs/toolkit';
import productReducer from './Slice/productSlice';
import categoryReducer from './Slice/categorySlice';
import userReducer from './Slice/userSlice'
const store = configureStore({
    reducer: {
        product: productReducer,
        category: categoryReducer,
        user: userReducer,
    },
});

export type RootState = ReturnType<typeof store.getState>;
export type AppDispatch = typeof store.dispatch;

export default store;
