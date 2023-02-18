import { StatusBar } from 'expo-status-bar';
import React, { useState } from 'react';
import { ScrollView, StyleSheet, Text, View } from 'react-native';

import Frontpage from './Frontpage';
import ButtonCount from './ButtonCount.js';
import Style from './Style'

export default function App() {
  return (
    <View style={container}>
    <ScrollView>
      <Frontpage/>
      <Text style={text}>Hei</Text>
      <ButtonCount/>
      <ButtonCount/>
      <ButtonCount/>
    </ScrollView>
    </View>
  );
}

const page = StyleSheet.create({
  container: {
    flex: 1,
    padding: 50,
    backgroundColor: '#61dafb',
  },
  text: {
    fontSize: 30,
    color: '#000',
  },
});

const container = StyleSheet.compose(page.container, page.text);
const text = StyleSheet.compose(page.text);

