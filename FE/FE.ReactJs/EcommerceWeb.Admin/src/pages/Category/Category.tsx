import DefaultLayout from '../../layout/DefaultLayout'
import Breadcrumb from '../../components/Breadcrumbs/Breadcrumb'
import { Link } from 'react-router-dom'
import CategoryList from '../../components/Categories/CategoryList'

const Category = () => {
  return (
    <DefaultLayout>
      <Breadcrumb pageName="Category Panel" />
      <Link
          to="/category/create"
          className="inline-flex items-center justify-center rounded-md border border-primary py-4 px-10 text-center font-medium text-primary hover:bg-opacity-90 lg:px-8 xl:px-10 gap-10 m-b-sm"
        >
          New Category +
        </Link>
      <div className="flex flex-col gap-10">
        <CategoryList />
      </div>
    </DefaultLayout>
  )
}

export default Category