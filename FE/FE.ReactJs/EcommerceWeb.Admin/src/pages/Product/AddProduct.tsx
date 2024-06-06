import DefaultLayout from '../../layout/DefaultLayout';
import Breadcrumb from '../../components/Breadcrumbs/Breadcrumb';
import AddProductForm from '../../components/Products/AddProductForm';

const CreateProduct = () => {
  return (
    <DefaultLayout>
      <Breadcrumb pageName="New Product" />

      <div className="flex flex-col gap-10">
        <AddProductForm/>
      </div>
    </DefaultLayout>
  )
}

export default CreateProduct