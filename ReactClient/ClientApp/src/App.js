import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { Counter } from './components/Counter';
import { Inventory } from './components/Inventory/Inventory';
import { InventoryAct } from './components/Inventory/InventoryAct';
import { InventorySettings } from './components/Inventory/InventorySettings';


export default class App extends Component {
  displayName = App.name

  render() {
    return (
      <Layout>
        <Route exact path='/' component={Home} />
        <Route path='/counter' component={Counter} />
            <Route path='/InventorySettings' component={InventorySettings} />
            <Route path='/inventory' component={Inventory} />
            <Route path='/inventoryAct/:mode/:id?' component={InventoryAct} />
      </Layout>
    );
  }
}
