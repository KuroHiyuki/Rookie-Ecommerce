import DefaultLayout from '../../layout/DefaultLayout';
import Breadcrumb from '../../components/Breadcrumbs/Breadcrumb';
import EditProductForm from '../../components/Products/UpdateProduct';

const CreateProduct = () => {
  return (
    <DefaultLayout>
      <Breadcrumb pageName="Edit" />

      <div className="flex flex-col gap-10">
        <EditProductForm/>
      </div>
    </DefaultLayout>
  )
}

export default CreateProduct