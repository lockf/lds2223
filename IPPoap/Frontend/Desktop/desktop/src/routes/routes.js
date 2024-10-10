import React from 'react';
import { BrowserRouter as Router, Routes, Route } from "react-router-dom"

import Login from '../pages/global/Login'
import CreateAccount from '../pages/global/CreateAccount'
import EventMenu from '../pages/global/EventMenu'
import PromotersMenu from '../pages/admin/PromotersMenu'
import DefinitionMenu from '../pages/global/DefinitonMenu'
import AccountMenu from '../pages/global/AccountMenu'
import ListEvents from '../pages/global/ListEvents'
import CreateEvent from '../pages/global/CreateEvent'
import CreatePromoter from '../pages/admin/CreatePromoter'
import CreateEventType from '../pages/admin/CreateEventType'
import CreateGroup from '../pages/admin/CreateGroup'
import CreateWhitelist from '../pages/admin/CreateWhitelist'
import EventTypes from '../pages/admin/EventTypes'
import Groups from '../pages/admin/Groups'
import WhitelistList from '../pages/admin/WhitelistList'

function Routing() {

    return (
      <>
        <Router>
          <Routes>
            <Route path="/" element={<Login/>} />
            <Route path="/CreateAccount" element={<CreateAccount/>} />
            <Route path="/EventMenu" element={<EventMenu/>} />
            <Route path="/PromotersMenu" element={<PromotersMenu/>} />
            <Route path="/DefinitionMenu" element={<DefinitionMenu/>} />
            <Route path="/AccountMenu" element={<AccountMenu/>} />
            <Route path="/ListEvents" element={<ListEvents/>} />
            <Route path="/CreateEvent" element={<CreateEvent/>} />
            <Route path="/CreatePromoter" element={<CreatePromoter/>} />
            <Route path="/CreateEventType" element={<CreateEventType/>} />
            <Route path="/CreateGroup" element={<CreateGroup/>} />
            <Route path="/CreateWhitelist" element={<CreateWhitelist/>} />
            <Route path="/EventTypes" element={<EventTypes/>} />
            <Route path="/Groups" element={<Groups/>} />
            <Route path="/WhitelistList" element={<WhitelistList/>} />
          </Routes> 
        </Router>
      </>
    );
  }
  
  export default Routing;
