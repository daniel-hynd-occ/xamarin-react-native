import {
  createStackNavigator,
} from 'react-navigation';

import React, { Component } from 'react';
import {
  AppRegistry,
  StyleSheet,
  View,
  Button
} from 'react-native';

import Graphs from './pages/Graphs';
import NativeModulesExample from './pages/NativeModulesExample';
import HomeScreen from './pages/HomeScreen';

const App = createStackNavigator({
  HomeScreen: { screen: HomeScreen },
  Graphs: { screen: Graphs },
  NativeModulesExample: { screen: NativeModulesExample}
});

export default App;


// Module name
AppRegistry.registerComponent('MyReactNativeApp', () => App);
