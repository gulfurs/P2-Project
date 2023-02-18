import { StatusBar } from 'expo-status-bar';
import React, { useState } from 'react';
import { StyleSheet, Text, View, TouchableOpacity} from 'react-native';


export default function ButtonCount() {
    const [count, setCount] = useState(0);
    return (
        <View style={button.container}>

            <TouchableOpacity
                style={button.but}
                onPress={() => {setCount(count + 1)}} >
                <Text style={button.but}>Click for + 1</Text>
            </TouchableOpacity>

            <TouchableOpacity
                style={button.but}
                onPress={() => {setCount(count - 1)}} >
                <Text style={button.but}>Click for - 1</Text>
            </TouchableOpacity>
            <Text style={button.but}>You clicked {count}</Text>
        </View>
    );
};

const button = StyleSheet.create({
    container: { 
        backgroundColor: "#fff",
        borderRadius: 10,
        padding: 15,
        marginVertical: 10
    },
    but: {
    backgroundColor: "#bbb",
    margin: 10, 
    fontSize: 30,
    fontWeight: '400',
    color: "#aaa",
    }
  });
