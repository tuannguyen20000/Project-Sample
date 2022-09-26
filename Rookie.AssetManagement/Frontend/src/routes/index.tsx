import React, { lazy, Suspense, useEffect } from "react";
import {
  Routes,
  Route
} from "react-router-dom";

import { HOME, BRAND, CHATAPP } from '../constants/pages';
import InLineLoader from "../components/InlineLoader";
import { useAppDispatch, useAppSelector } from "../hooks/redux";
import LayoutRoute from "./LayoutRoute";
import Roles from "src/constants/roles";
import { me } from "src/containers/Authorize/reducer";

const Home = lazy(() => import('../containers/Home'));
const Login = lazy(() => import('../containers/Authorize'));
const Brand = lazy(() => import('../containers/Brand'));
const ChatApp = lazy(() => import('../containers/ChatApp'));
const Brand1 = lazy(() => import('../containers/Brand1'));
const NotFound = lazy(() => import("../containers/NotFound"));

const SusspenseLoading = ({ children }) => (
  <Suspense fallback={<InLineLoader />}>
    {children}
  </Suspense>
);

const AppRoutes = () => {
  const { isAuth, account } = useAppSelector(state => state.authReducer);
  const dispatch = useAppDispatch();

  useEffect(() => {

  }, []);

  return (
    <SusspenseLoading>
      <Routes>
        <Route 
          path={HOME} 
          element={
            <LayoutRoute>
              <Brand />
            </LayoutRoute>
          } 
        />
        <Route 
          path={BRAND} 
          element={
            <LayoutRoute>
              <Brand />
            </LayoutRoute>

          } 
        />
        <Route 
          path={CHATAPP} 
          element={
            <LayoutRoute>
              <ChatApp />
            </LayoutRoute>
          } 
        />
      </Routes>
    </SusspenseLoading>
  )
};

export default AppRoutes;
