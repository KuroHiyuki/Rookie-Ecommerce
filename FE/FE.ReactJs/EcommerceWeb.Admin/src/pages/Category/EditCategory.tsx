import DefaultLayout from '../../layout/DefaultLayout';
import Breadcrumb from '../../components/Breadcrumbs/Breadcrumb';
import UpdateCategory from '../../components/Categories/UpdateCategory';

const EditCategory = () => {
  return (
    <DefaultLayout>
      <Breadcrumb pageName="Edit" />

      <div className="flex flex-col gap-10">
        <UpdateCategory/>
      </div>
    </DefaultLayout>
  )
}

export default EditCategory