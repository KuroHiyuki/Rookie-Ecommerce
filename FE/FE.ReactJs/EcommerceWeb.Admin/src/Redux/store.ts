import { configureStore } from '@reduxjs/toolkit';
import productSlice from './Slice/productSlice';

const store = configureStore({
    reducer: {
        product:productSlice
    },
});

export type RootState = ReturnType<typeof store.getState>;
export type AppDispatch = typeof store.dispatch;

export default store;
