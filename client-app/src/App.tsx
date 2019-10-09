import React, { Component } from 'react';
import { Header, Icon, List } from 'semantic-ui-react';

import axios from 'axios';

import './App.css';

class App extends Component {
  state = {
    values: []
  };

  componentDidMount() {
    axios.get('http://localhost:5000/values').then(res => {
      this.setState({
        values: res.data
      });
    });
  }

  render() {
    return (
      <div>
        <Header as='h2'>
          <Icon name='users' />
          <Header.Content>.NET Core 3.0 | ReactJS | TypeScript</Header.Content>
        </Header>
        <List>
          {this.state.values.map((value: any) => (
            <List.Item key={value.id}>{value.name}</List.Item>
          ))}
        </List>
      </div>
    );
  }
}

export default App;
