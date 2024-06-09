import { useEffect, useState } from 'react';
import { Navigate, Route, Routes, useLocation } from 'react-router-dom';
import Loader from './common/Loader';
import PageTitle from './components/PageTitle';
import ECommerce from './pages/Dashboard/ECommerce';
import Settings from './pages/Settings';
import Product from './pages/Product/Product';
import CreateProduct from './pages/Product/AddProduct';
import EditProduct from './pages/Product/EditProduct';
import Category from './pages/Category/Category';
import CreateCategory from './pages/Category/CreateCategory';
import EditCategory from './pages/Category/EditCategory';
import User from './pages/User/User';
import EditUser from './pages/User/EditUset';
import SignIn from './pages/Authentication/SignIn';
import Cookies from 'js-cookie';
interface PrivateRouteProps {
  children: React.ReactNode;
}

const PrivateRoute: React.FC<PrivateRouteProps> = ({ children }) => {
  const token = Cookies.get('authToken');

  if (token) {
    return <Navigate to="/signin" />;
  }

  return <>{children}</>;
};
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
          path="/signin"
          element={
            <>
              <PageTitle title="Sign In"/>
              <SignIn/>
            </>
          }
        />
        <Route
          index
          element={
            <>
              <PageTitle title="Rookie Ecommerce" />
              <PrivateRoute>
              <ECommerce />
              </PrivateRoute>
              
            </>
          }
        />
        <Route
          index
          element={
            <>
              <PageTitle title="Rookie Ecommerce" />
              <PrivateRoute>
                <Product/>
              </PrivateRoute>
              
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
          path="/category"
          element={
            <>
              <PageTitle title="category"/>
              <Category/>
            </>
          }
        />
        <Route
          path="/category/create"
          element={
            <>
              <PageTitle title="Create"/>
              <CreateCategory/>
            </>
          }
        />
        <Route
          path="/category/edit/:id"
          element={
            <>
              <PageTitle title="Edit"/>
              <EditCategory/>
            </>
          }
        />
        <Route
          path="/user"
          element={
            <>
              <PageTitle title="User"/>
              <User/>
            </>
          }
        />
        <Route
          path="/user/edit/:id"
          element={
            <>
              <PageTitle title="Edit"/>
              <EditUser/>
            </>
          }
        />
        <Route
          path="/settings"
          element={
            <>
              <PageTitle title="Settings" />
              <Settings />
            </>
          }
        />
      </Routes>
    </>
  );
}

export default App;
