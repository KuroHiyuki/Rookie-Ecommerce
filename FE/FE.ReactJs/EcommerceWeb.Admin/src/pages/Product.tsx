import React from 'react';
import DefaultLayout from '../layout/DefaultLayout';
import Breadcrumb from '../components/Breadcrumbs/Breadcrumb';

const Product = () => {
  return (
    <DefaultLayout>
        <Breadcrumb pageName="Product"/>
        <div> Hello</div>
    </DefaultLayout>
  )
}

export default Product