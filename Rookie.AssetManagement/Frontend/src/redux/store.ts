import { configureStore, getDefaultMiddleware, combineReducers } from '@reduxjs/toolkit';
import createSagaMiddleware from 'redux-saga';


import authReducer from 'src/containers/Authorize/reducer';
import brandReducer from 'src/containers/Brand/reducer';
import brand1Reducer from 'src/containers/Brand1/reducer';

import rootSaga from './sagas/rootSaga';

const reducer = combineReducers({
    authReducer,
    brandReducer,
    brand1Reducer
});

const sagaMiddleware = createSagaMiddleware();

const store = configureStore({
    reducer,
    middleware: [
        ...getDefaultMiddleware({
            thunk: false,
            serializableCheck: false,
        }),
        sagaMiddleware
    ],
});

rootSaga.map(saga => sagaMiddleware.run(saga))  // Register all sagas

// sagaMiddleware.run(watcherSaga);

export default store;

export type RootState = ReturnType<typeof store.getState>;
export type RootDispatch = typeof store.dispatch;
