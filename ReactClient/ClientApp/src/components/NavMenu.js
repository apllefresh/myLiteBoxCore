﻿import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import { Glyphicon, Nav, Navbar, NavItem } from 'react-bootstrap';
import { LinkContainer } from 'react-router-bootstrap';
import './NavMenu.css';

export class NavMenu extends Component {
    displayName = NavMenu.name

    render() {
        return (
            <Navbar inverse fixedTop fluid collapseOnSelect>
                <Navbar.Header>
                    <Navbar.Brand>
                        <Link to={'/'}>ReactClient</Link>
                    </Navbar.Brand>
                    <Navbar.Toggle />
                </Navbar.Header>
                <Navbar.Collapse>
                    <Nav>
                        <LinkContainer to={'/'} exact>
                            <NavItem>
                                <Glyphicon glyph='home' /> Home
                            </NavItem>
                        </LinkContainer>

                        <LinkContainer to={'/inventory'}>
                            <NavItem>
                                <Glyphicon glyph='education' /> inventory
                            </NavItem>
                        </LinkContainer>
                        <LinkContainer to={'/InventorySettings'}>
                            <NavItem>
                                <Glyphicon glyph='th-list' /> Inventory Settings
                            </NavItem>
                        </LinkContainer>
                        <LinkContainer to={'/InventoryResult'}>
                            <NavItem>
                                <Glyphicon glyph='th-list' /> Inventory Result
                            </NavItem>
                        </LinkContainer>

                    </Nav>
                </Navbar.Collapse>
            </Navbar>
        );
    }
}
