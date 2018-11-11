import React from 'react';
import ReactDOM from 'react-dom';
import { Route, Switch, Redirect } from 'react-router-dom';
import Inventory from '../containers/inventory/inventory.jsx';


export default class Routing extends React.Component {

    render() {
        return (
            <main>
                <Switch>
                    <Route path="/inventory" component={Inventory} />
                    <Route exact path="/" render={() => (<Redirect to="/inventory" />)} />
                </Switch>
            </main>
        );
    }
};
