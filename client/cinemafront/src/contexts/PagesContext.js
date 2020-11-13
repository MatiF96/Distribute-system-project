import React, { createContext, useState } from 'react';

import Home from '../containers/Home';
import Halls from '../containers/Halls/Halls';
import Movies from '../containers/Movies';

export const PagesContext = createContext();

const PagesContextProvider = ({ children }) => {
    // eslint-disable-next-line
    const [pages, setPages] = useState([
        {label: 'Strona główna', url: '/', component: Home},
        {label: 'Sale', url: '/halls', component: Halls},
        {label: 'Filmy', url: '/movies', component: Movies},
    ]);

    return (
        <PagesContext.Provider value={{pages}}>
            {children}
        </PagesContext.Provider>
    )
}

export default PagesContextProvider;