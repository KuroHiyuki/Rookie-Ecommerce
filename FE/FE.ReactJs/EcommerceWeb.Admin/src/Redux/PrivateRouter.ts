// import React from 'react';
// import { Navigate } from 'react-router-dom';
// import { useAppSelector } from './hooks';

// interface PrivateRouteProps {
//   children: React.ReactNode;
// }

// const PrivateRoute: React.FC<PrivateRouteProps> = ({ children }) => {
//   const isAuthenticated = useAppSelector((state) => state.auth.token);

//   if (!isAuthenticated) {
//     return <Navigate {to="/"} />;
//   }

//   return <>{children}</>;
// };

// export default PrivateRoute;
