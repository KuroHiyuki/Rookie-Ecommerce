import DefaultLayout from '../../layout/DefaultLayout';
import Breadcrumb from '../../components/Breadcrumbs/Breadcrumb';
import AddCategory from '../../components/Categories/AddCategoryForm';

const CreateCategory = () => {
  return (
    <DefaultLayout>
      <Breadcrumb pageName="New Catgory" />

      <div className="flex flex-col gap-10">
        <AddCategory/>
      </div>
    </DefaultLayout>
  )
}

export default CreateCategory