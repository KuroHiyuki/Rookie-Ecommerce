import { useEffect, useState } from 'react';
import { Route, Routes, useLocation } from 'react-router-dom';
import Loader from './common/Loader';
import PageTitle from './components/PageTitle';
import ECommerce from './pages/Dashboard/ECommerce';
import Settings from './pages/Settings';
import Product from './pages/Product/Product';
import CreateProduct from './pages/Product/AddProduct';
import EditProduct from './pages/Product/EditProduct';
import Category from './pages/Category/Category';

function App() {
  const [loading, setLoading] = useState<boolean>(true);
  const { pathname } = useLocation();

  useEffect(() => {
    window.scrollTo(0, 0);
  }, [pathname]);

  useEffect(() => {
    setTimeout(() => setLoading(false), 1000);
  }, []);

  return loading ? (
    <Loader />
  ) : (
    <>
      <Routes>
        <Route
          index
          element={
            <>
              <PageTitle title="Rookie Ecommerce" />
              <ECommerce />
            </>
          }
        />
        <Route
          index
          element={
            <>
              <PageTitle title="Rookie Ecommerce" />
              <Product/>
            </>
          }
        />
        <Route
          path="/Product"
          element={
            <>
              <PageTitle title="Product"/>
              <Product/>
            </>
          }
        />
        <Route
          path="/category"
          element={
            <>
              <PageTitle title="category"/>
              <Category/>
            </>
          }
        />
        <Route
          path="/Product/Create"
          element={
            <>
              <PageTitle title="Create"/>
              <CreateProduct/>
            </>
          }
        />
        <Route
          path="/Product/Edit/:id"
          element={
            <>
              <PageTitle title="Edit"/>
              <EditProduct/>
            </>
          }
        />
        <Route
          path="/settings"
          element={
            <>
              <PageTitle title="Settings | TailAdmin - Tailwind CSS Admin Dashboard Template" />
              <Settings />
            </>
          }
        />
      </Routes>
    </>
  );
}

export default App;
