import DefaultLayout from '../../layout/DefaultLayout';
import Breadcrumb from '../../components/Breadcrumbs/Breadcrumb';
import ProductList from '../../components/Products/ProductList';
import { Link } from 'react-router-dom';

const Product = () => {
  return (
    <DefaultLayout>
      <Breadcrumb pageName="Product Panel" />
      <Link
          to="/product/create"
          className="inline-flex items-center justify-center rounded-md border border-primary py-4 px-10 text-center font-medium text-primary hover:bg-opacity-90 lg:px-8 xl:px-10 gap-10 m-b-sm"
        >
          New Product +
        </Link>
      <div className="flex flex-col gap-10">
        <ProductList />
      </div>
    </DefaultLayout>
  );
};

export default Product;
