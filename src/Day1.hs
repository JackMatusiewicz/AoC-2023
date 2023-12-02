module Day1 (solvePartOne) where

import Scaffolding
import Data.Char(isDigit, digitToInt)

findFirst :: String -> Char
findFirst [] = '0'
findFirst (h:t) = if isDigit h then h else findFirst t

findLast :: String -> Char -> Char
findLast "" x = x
findLast (h:t) v  = findLast t (if isDigit h then h else v)

getNumber :: String -> Int
getNumber chars =
    digitToInt (findFirst chars) * 10 + digitToInt (findLast chars '0')

-- | Remove convertInput to get answer for part one.
getNumbers :: [String] -> Int
getNumbers = sum . fmap (getNumber . convertInput)

convertInput :: String -> String
convertInput [] = []
convertInput ('o':'n':'e':t) = '1' : convertInput ('e' : t)
convertInput ('t':'w':'o':t) = '2' : convertInput ('o' : t)
convertInput ('t':'h':'r':'e':'e':t) = '3' : convertInput ('e' : t)
convertInput ('f':'o':'u':'r':t) = '4' : convertInput t
convertInput ('f':'i':'v':'e':t) = '5' : convertInput ('e' : t)
convertInput ('s':'i':'x':t) = '6' : convertInput t
convertInput ('s':'e':'v':'e':'n':t) = '7' : convertInput ('n' : t)
convertInput ('e':'i':'g':'h':'t':t) = '8' : convertInput ('t' : t)
convertInput ('n':'i':'n':'e':t) = '9' : convertInput ('e' : t)
convertInput (h:t) = if isDigit h then h : convertInput t else convertInput t


solvePartOne :: IO ()
solvePartOne = do
    lines <- getData "DayOneData.txt"
    putStrLn . show $ getNumbers lines