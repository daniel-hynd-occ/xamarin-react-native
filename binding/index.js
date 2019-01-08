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
  NativeEventEmitter,
  Dimensions
} from 'react-native';
import Svg, {
  Circle,
  Rect
} from 'react-native-svg';

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
      (err) => {
        console.error(err);
      },
      (x) => {
        Alert.alert(x);
      }
    );
  }

  _onPressPromiseButton = async function () {
    try {
      var x = await NativeModules.RNG.nextNegative(10, 20);
      Alert.alert('Number is:' + x);
    }
    catch (e) {
      console.error(e);
    }
  }

  async doTest() {
    try {
      var result = await NativeModules.RNG.test("some words");
      console.log(result);
    }
    catch (e) {
      console.log(e);
    }
  }

  async doShow() {
    await NativeModules.ToastExample.show();
  }

  _addOne = function () {
    NativeModules.RNG.addOne(1, (error, result) => {
      if (error) {
        console.log(error);
      }
      else {
        console.log("add one", result);
      }
    });
  }

  _addTwo = function () {
    NativeModules.RNG.addTwo(10, (error, result) => {
      if (error) {
        console.log(error);
      }
      else {
        console.log("add two", result);
      }
    });
  }

  _sendEvent = function () {
    NativeModules.Events.send();
  }

  componentDidMount() {
    const emitter = new NativeEventEmitter(NativeModules.Events);
    const listener = emitter.addListener("AnEvent", (e) => console.log("event", e));
  }

  async square() {
    try {
      const x2 = await NativeModules.RNG.square(2);
      console.log("square", x2);
    }
    catch (e) {
      console.log(e);
    }
  }

  render() {
    const { width, height } = Dimensions.get('window');

    return (
      <View style={styles.container}>
        <View>
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
            onPress={this._addOne}
            title="Callback"
          />
          <Button
            onPress={this._addTwo}
            title="Callback 2"
          />
          <Button
            onPress={this._sendEvent}
            title="Event"
          />
          <Button
            onPress={this.square}
            title="Promise"
          />
        </View>
        <View>
          <Svg height={height * 0.5} width={width * 0.5} viewBox="0 0 100 100">
            <Circle
              cx="50"
              cy="50"
              r="45"
              stroke="blue"
              strokeWidth="2.5"
              fill="green"
            />
            <Rect
              x="15"
              y="15"
              width="70"
              height="70"
              stroke="red"
              strokeWidth="2"
              fill="yellow"
            />
          </Svg>
        </View>
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
