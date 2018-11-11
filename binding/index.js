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
  NativeModules,
  NativeEventEmitter
} from 'react-native';

const instructions = Platform.select({
  ios: 'Press Cmd+R to reload,\n' +
    'Cmd+D or shake for dev menu',
  android: 'Double tap R on your keyboard to reload,\n' +
    'Shake or press menu button for dev menu',
});

class RNHelloWorld extends Component<{}> {
  _onPressToastButton() {
	  NativeModules.ToastExample.show();
  }
	
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
      var x = await NativeModules.RNG.nextNegative(10,20);
      Alert.alert('Number is:' + x);
    }
    catch(e)
    {
      console.error(e);
    }
  }

  async doTest(){
    try{
      var result = await NativeModules.RNG.test("some words");
      console.log(result);
    }
    catch(e){
      console.log(e);
    }
  }

  async doShow(){
    await NativeModules.ToastExample.show();
  }

  async doNotify(){
    NativeModules.RNG.notify((error, result) => {
      if(error){
        console.log(error);
      }
      else{
        console.log(result);
      }
    });
  }

  _sendEvent = function(){
    NativeModules.Events.send();
  }

  componentDidMount(){
    const emitter = new NativeEventEmitter(NativeModules.Events);
    emitter.addListener("AnEvent", (e) => console.log(e));
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
          Test 123 abc !
        </Text>
        <Button 
          onPress = {this.doNotify}
          title="Promise"
          />
        <Button 
          onPress = {this._sendEvent}
          title="Event"
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
