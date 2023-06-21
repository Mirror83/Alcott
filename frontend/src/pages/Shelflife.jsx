import React from "react";
import ReactDOM from "react-dom/client";
import { ChakraProvider } from "@chakra-ui/react";
import Navbar from "../components/Navbar";
import { Button, Radio, RadioGroup, Stack } from "@chakra-ui/react";

function Shelflife() {
  return (
    <>
      <div>
        <Navbar />
        <br />
        <Button colorScheme="gray">Search product</Button>
        <RadioGroup defaultValue="1">
          <Stack>
            <Radio value="1">Weekly</Radio>
            <Radio value="2">Monthly</Radio>
          </Stack>
        </RadioGroup>
        <br />
        <br />
        <Button colorScheme="gray">Compute Shelflife</Button>
      </div>
    </>
  );
}

export default Shelflife;
