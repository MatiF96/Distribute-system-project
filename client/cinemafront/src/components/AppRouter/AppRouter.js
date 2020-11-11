import React, {useContext} from 'react';
import {Switch, Route} from "react-router-dom";
import {PagesContext} from '../../contexts/PagesContext';

const AppRouter = () => {
    const { pages } = useContext(PagesContext);
  return (
    <Switch>
        {pages.map((page,index)=>{
            return (
                <Route
                component={page.component}
                key={index}
                exact={true}
                path={page.url}
                />
            )
        })}
    </Switch>
)};

export default AppRouter;