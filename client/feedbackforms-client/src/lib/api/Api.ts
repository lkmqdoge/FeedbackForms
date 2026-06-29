/* eslint-disable */
/* tslint:disable */
// @ts-nocheck
/*
 * ---------------------------------------------------------------
 * ## THIS FILE WAS GENERATED VIA SWAGGER-TYPESCRIPT-API        ##
 * ##                                                           ##
 * ## AUTHOR: acacode                                           ##
 * ## SOURCE: https://github.com/acacode/swagger-typescript-api ##
 * ---------------------------------------------------------------
 */

export interface AnswerDto {
  userName?: string | null;
  email?: string | null;
  text?: string | null;
}

export interface CreateAnswerRequest {
  /** @format uuid */
  topicId?: string;
  email?: string | null;
  userName?: string | null;
  text?: string | null;
  captchaToken?: string | null;
}

export interface CreateTopicRequest {
  title?: string | null;
  body?: string | null;
  /** @format uuid */
  userId?: string;
}

export interface LoginUserRequest {
  email?: string | null;
  password?: string | null;
}

export interface RegisterUserRequest {
  userName?: string | null;
  email?: string | null;
  password?: string | null;
}

export interface TopicDto {
  /** @format uuid */
  id?: string;
  title?: string | null;
  body?: string | null;
  isOwner?: boolean;
}

export interface UserDto {
  id?: string | null;
  userName?: string | null;
  email?: string | null;
}

import type {
  AxiosInstance,
  AxiosRequestConfig,
  AxiosResponse,
  HeadersDefaults,
  ResponseType,
} from "axios";
import axios from "axios";

export type QueryParamsType = Record<string | number, any>;

export interface FullRequestParams
  extends Omit<AxiosRequestConfig, "data" | "params" | "url" | "responseType"> {
  /** set parameter to `true` for call `securityWorker` for this request */
  secure?: boolean;
  /** request path */
  path: string;
  /** content type of request body */
  type?: ContentType;
  /** query params */
  query?: QueryParamsType;
  /** format of response (i.e. response.json() -> format: "json") */
  format?: ResponseType;
  /** request body */
  body?: unknown;
}

export type RequestParams = Omit<
  FullRequestParams,
  "body" | "method" | "query" | "path"
>;

export interface ApiConfig<SecurityDataType = unknown>
  extends Omit<AxiosRequestConfig, "data" | "cancelToken"> {
  securityWorker?: (
    securityData: SecurityDataType | null,
  ) => Promise<AxiosRequestConfig | void> | AxiosRequestConfig | void;
  secure?: boolean;
  format?: ResponseType;
}

export enum ContentType {
  Json = "application/json",
  JsonApi = "application/vnd.api+json",
  FormData = "multipart/form-data",
  UrlEncoded = "application/x-www-form-urlencoded",
  Text = "text/plain",
}

export class HttpClient<SecurityDataType = unknown> {
  public instance: AxiosInstance;
  private securityData: SecurityDataType | null = null;
  private securityWorker?: ApiConfig<SecurityDataType>["securityWorker"];
  private secure?: boolean;
  private format?: ResponseType;

  constructor({
    securityWorker,
    secure,
    format,
    ...axiosConfig
  }: ApiConfig<SecurityDataType> = {}) {
    this.instance = axios.create({
      ...axiosConfig,
      baseURL: axiosConfig.baseURL || "",
    });
    this.secure = secure;
    this.format = format;
    this.securityWorker = securityWorker;
  }

  public setSecurityData = (data: SecurityDataType | null) => {
    this.securityData = data;
  };

  protected mergeRequestParams(
    params1: AxiosRequestConfig,
    params2?: AxiosRequestConfig,
  ): AxiosRequestConfig {
    const method = params1.method || (params2 && params2.method);

    return {
      ...this.instance.defaults,
      ...params1,
      ...(params2 || {}),
      headers: {
        ...((method &&
          this.instance.defaults.headers[
            method.toLowerCase() as keyof HeadersDefaults
          ]) ||
          {}),
        ...(params1.headers || {}),
        ...((params2 && params2.headers) || {}),
      },
    };
  }

  protected stringifyFormItem(formItem: unknown) {
    if (typeof formItem === "object" && formItem !== null) {
      return JSON.stringify(formItem);
    } else {
      return `${formItem}`;
    }
  }

  protected createFormData(input: Record<string, unknown>): FormData {
    if (input instanceof FormData) {
      return input;
    }
    return Object.keys(input || {}).reduce((formData, key) => {
      const property = input[key];
      const propertyContent: any[] =
        property instanceof Array ? property : [property];

      for (const formItem of propertyContent) {
        const isFileType = formItem instanceof Blob || formItem instanceof File;
        formData.append(
          key,
          isFileType ? formItem : this.stringifyFormItem(formItem),
        );
      }

      return formData;
    }, new FormData());
  }

  public request = async <T = any, _E = any>({
    secure,
    path,
    type,
    query,
    format,
    body,
    ...params
  }: FullRequestParams): Promise<AxiosResponse<T>> => {
    const secureParams =
      ((typeof secure === "boolean" ? secure : this.secure) &&
        this.securityWorker &&
        (await this.securityWorker(this.securityData))) ||
      {};
    const requestParams = this.mergeRequestParams(params, secureParams);
    const responseFormat = format || this.format || undefined;

    if (
      type === ContentType.FormData &&
      body &&
      body !== null &&
      typeof body === "object"
    ) {
      body = this.createFormData(body as Record<string, unknown>);
    }

    if (
      type === ContentType.Text &&
      body &&
      body !== null &&
      typeof body !== "string"
    ) {
      body = JSON.stringify(body);
    }

    return this.instance.request({
      ...requestParams,
      headers: {
        ...(requestParams.headers || {}),
        ...(type ? { "Content-Type": type } : {}),
      },
      params: query,
      responseType: responseFormat,
      data: body,
      url: path,
    });
  };
}

/**
 * @title FeedbackForms
 * @version v1
 * @contact lkmqdoge <leere0@proton.me>
 *
 * FeedbackForms api
 */
export class Api<
  SecurityDataType extends unknown,
> extends HttpClient<SecurityDataType> {
  api = {
    /**
     * No description
     *
     * @tags FeedbackForms.WebApi
     * @name HelloList
     * @request GET:/api/hello
     */
    helloList: (params: RequestParams = {}) =>
      this.request<string, any>({
        path: `/api/hello`,
        method: "GET",
        ...params,
      }),

    /**
     * No description
     *
     * @tags FeedbackForms.WebApi
     * @name TopicsCreate
     * @request POST:/api/topics
     */
    topicsCreate: (data: CreateTopicRequest, params: RequestParams = {}) =>
      this.request<string, void>({
        path: `/api/topics`,
        method: "POST",
        body: data,
        type: ContentType.Json,
        format: "json",
        ...params,
      }),

    /**
     * No description
     *
     * @tags FeedbackForms.WebApi
     * @name TopicsDetail
     * @request GET:/api/topics/{id}
     */
    topicsDetail: (id: string, params: RequestParams = {}) =>
      this.request<TopicDto, void>({
        path: `/api/topics/${id}`,
        method: "GET",
        format: "json",
        ...params,
      }),

    /**
     * No description
     *
     * @tags FeedbackForms.WebApi
     * @name TopicsByUserDetail
     * @request GET:/api/topics/byUser/{id}
     */
    topicsByUserDetail: (id: string, params: RequestParams = {}) =>
      this.request<TopicDto[], void>({
        path: `/api/topics/byUser/${id}`,
        method: "GET",
        format: "json",
        ...params,
      }),

    /**
     * No description
     *
     * @tags FeedbackForms.WebApi
     * @name AnswersCreate
     * @request POST:/api/answers
     */
    answersCreate: (data: CreateAnswerRequest, params: RequestParams = {}) =>
      this.request<string, void>({
        path: `/api/answers`,
        method: "POST",
        body: data,
        type: ContentType.Json,
        format: "json",
        ...params,
      }),

    /**
     * No description
     *
     * @tags FeedbackForms.WebApi
     * @name AnswersByTopicDetail
     * @request GET:/api/answers/byTopic/{id}
     */
    answersByTopicDetail: (id: string, params: RequestParams = {}) =>
      this.request<AnswerDto[], void>({
        path: `/api/answers/byTopic/${id}`,
        method: "GET",
        format: "json",
        ...params,
      }),

    /**
     * No description
     *
     * @tags FeedbackForms.WebApi
     * @name UsersRegisterCreate
     * @request POST:/api/users/register
     */
    usersRegisterCreate: (
      data: RegisterUserRequest,
      params: RequestParams = {},
    ) =>
      this.request<string, any>({
        path: `/api/users/register`,
        method: "POST",
        body: data,
        type: ContentType.Json,
        format: "json",
        ...params,
      }),

    /**
     * No description
     *
     * @tags FeedbackForms.WebApi
     * @name UsersLoginCreate
     * @request POST:/api/users/login
     */
    usersLoginCreate: (data: LoginUserRequest, params: RequestParams = {}) =>
      this.request<string, any>({
        path: `/api/users/login`,
        method: "POST",
        body: data,
        type: ContentType.Json,
        ...params,
      }),

    /**
     * No description
     *
     * @tags FeedbackForms.WebApi
     * @name UsersMeList
     * @request GET:/api/users/me
     */
    usersMeList: (params: RequestParams = {}) =>
      this.request<UserDto, any>({
        path: `/api/users/me`,
        method: "GET",
        format: "json",
        ...params,
      }),
  };
}
