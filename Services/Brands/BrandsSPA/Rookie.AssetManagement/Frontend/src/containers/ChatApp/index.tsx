import React, { lazy } from 'react';
import { Route, Routes } from 'react-router-dom';

import { CHAT_LIST } from 'src/constants/pages';
import LayoutRoute from 'src/routes/LayoutRoute';

const NotFound = lazy(() => import("../NotFound"));
const ChatList = lazy(() => import("./List"));

const ChatApp = () => {
    return (
        <Routes>
            <Route path={CHAT_LIST} element={<ChatList />} />
        </Routes>
    )
};

export default ChatApp;