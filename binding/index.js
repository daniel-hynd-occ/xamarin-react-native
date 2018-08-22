/**
 * Sample React Native App
 * https://github.com/facebook/react-native
 * @flow
 */

import React, { Component } from 'react';
import {
  Alert,
  AppRegistry,
  Platform,
  StyleSheet,
  Text,
  View,
  Button,
  NativeModules
} from 'react-native';

const instructions = Platform.select({
  ios: 'Press Cmd+R to reload,\n' +
    'Cmd+D or shake for dev menu',
  android: 'Double tap R on your keyboard to reload,\n' +
    'Shake or press menu button for dev menu',
});

class RNHelloWorld extends Component<{}> {
  _onPressCallbackButton() {
	  NativeModules.RNG.nextAsString(
      (err)=>{
        console.error(err);
      },
      (x) => {
        Alert.alert(x);
      }
    );
  }

  _onPressPromiseButton = async function() {
    try{
      var {x} = await NativeModules.RNG.nextNegative(10,20);
      Alert.alert('Number is:' + x);
    }
    catch(e)
    {
      console.error(e);
    }
  }
	
  render() {
    return (
      <View style={styles.container}>
        <Text style={styles.welcome}>
          Hey there! Wassup?
        </Text>
        <Text style={styles.instructions}>
          To get started, edit App.js
        </Text>
        <Text style={styles.instructions}>
          {instructions}
        </Text>
        <Text>
          Test ? ! zzz
        </Text>
        <Button
          onPress={this._onPressCallbackButton}
          title="Callback"
          color="#841584"
        />
        <Button
          onPress={this._onPressPromiseButton}
          title="Promise"
          color="#4da058"
        />
      </View>
    );
  }
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    justifyContent: 'center',
    alignItems: 'center',
    backgroundColor: '#F5FCFF',
  },
  welcome: {
    fontSize: 20,
    textAlign: 'center',
    margin: 10,
  },
  instructions: {
    textAlign: 'center',
    color: '#333333',
    marginBottom: 5,
  },
});

// Module name
AppRegistry.registerComponent('MyReactNativeApp', () => RNHelloWorld);
