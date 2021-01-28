package com.algexperimental;

import java.net.MalformedURLException;
import java.net.URL;

public class Main {

    public static void main(String[] args) {
	// write your code here

        try {
            new UnionFindFactory().BuildWeightedQuickUnionUF(new URL(args[0]));
        } catch (MalformedURLException e) {
            e.printStackTrace();
        }
    }
}
