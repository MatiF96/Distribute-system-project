import React, { createContext, useState } from 'react';

import Showings from '../containers/Showings';
import Halls from '../containers/Halls/Halls';
import Movies from '../containers/Movies';
import Employees from '../containers/Employees';

export const PagesContext = createContext();

const PagesContextProvider = ({ children }) => {
    // eslint-disable-next-line
    const [pages, setPages] = useState([
        {label: 'Seanse', url: '/', component: Showings, protected: false},
        {label: 'Sale', url: '/halls', component: Halls, protected: true},
        {label: 'Filmy', url: '/movies', component: Movies, protected: true},
        {label: 'Pracownicy', url: '/employees', component: Employees, protected: true},
    ]);

    return (
        <PagesContext.Provider value={{pages}}>
            {children}
        </PagesContext.Provider>
    )
}

export default PagesContextProvider;