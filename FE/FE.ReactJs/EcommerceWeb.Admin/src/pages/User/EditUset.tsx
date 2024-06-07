import DefaultLayout from '../../layout/DefaultLayout';
import Breadcrumb from '../../components/Breadcrumbs/Breadcrumb';
import UpdatUser from '../../components/Users/UpdateUset';

const EditUser = () => {
  return (
    <DefaultLayout>
      <Breadcrumb pageName="User Panel" />
      <div className="flex flex-col gap-10">
        <UpdatUser/>
      </div>
    </DefaultLayout>
  );
};

export default EditUser;