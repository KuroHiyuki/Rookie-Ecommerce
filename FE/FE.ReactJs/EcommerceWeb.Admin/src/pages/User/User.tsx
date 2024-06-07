import DefaultLayout from '../../layout/DefaultLayout';
import Breadcrumb from '../../components/Breadcrumbs/Breadcrumb';
import UserList from '../../components/Users/UserList';

const User = () => {
  return (
    <DefaultLayout>
      <Breadcrumb pageName="User Panel" />
      <div className="flex flex-col gap-10">
        <UserList />
      </div>
    </DefaultLayout>
  );
};

export default User;