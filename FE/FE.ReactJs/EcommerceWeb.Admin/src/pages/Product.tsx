import DefaultLayout from '../layout/DefaultLayout';
import Breadcrumb from '../components/Breadcrumbs/Breadcrumb';
import ProductList from '../components/Products/ProductList';

const Product = () => {
  return (
    <DefaultLayout>
      <Breadcrumb pageName="Product Panel" />

      <div className="flex flex-col gap-10">
        <ProductList/>
      </div>
    </DefaultLayout>
  )
}

export default Product